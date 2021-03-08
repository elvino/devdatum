using DevDatum.Domain.ContractRepositories;
using DevDatum.Domain.Entities;
using DevDatum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DevDatum.Controllers
{
    [Route("v1/")]
    public class InterestController : ControllerBase
    {
        private readonly IInterestRepository repository;
        private readonly IConfiguration config;
        private readonly ILogger<FeesController> logger;

        public InterestController(IInterestRepository repository, ILogger<FeesController> logger, IConfiguration config)
        {
            this.repository = repository;
            this.logger = logger;
            this.config = config;
        }

        [HttpGet]
        [Route("calculajuros/{valorInicial:decimal}/{meses:int}")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public ActionResult<IEnumerable<Interest>> TaxFee(decimal valorInicial, int meses)
        {
            try
            {
                logger.LogInformation($"Informativo: Chamada Api Calculo Taxa de Juros Iniciada");

                var taxCalc = new Interest(valorInicial, meses).CalculateFee(new Fees().GetTaxFee);

                logger.LogInformation($"Informativo: Chamada Api Calculo Taxa de Juros Finalizada");

                return Ok(string.Format("{0:N2}", taxCalc));
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro:{ex.Message}");
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("showmethecode")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public ActionResult<IEnumerable<Interest>> ShowGit()
        {
            try
            {
                logger.LogInformation($"Informativo: Chamada Api Mostrar GIT Iniciada");

                var git = new Git(config.GetSection("Git").Value);

                logger.LogInformation($"Informativo: Chamada Api Mostrar GIT Finalizada");

                return Ok(git.ShowGit());
            }
            catch (Exception ex)
            {
                logger.LogError($"Erro:{ex.Message}");
                return BadRequest();
            }
        }


        /*
         * CRUD - DESCOMENTAR CASO DESEJE EXECUTAR OPERACOES
         *
        [HttpGet]
        [Route("/listar")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public ActionResult<List<InterestModel>> GetAll()
        {
            var interest = repository.GetAll();

            try
            {
                if (interest == null) return NotFound();

                var listModel = new List<InterestModel>();

                foreach (var inter in interest)
                {
                    var model = new InterestModel();
                    model.Id = inter.Id;
                    model.Name = inter.Name;
                    model.InitialValue = inter.InitialValue;
                    model.FinalValue = inter.FinalValue;
                    model.Time = inter.Time;

                    listModel.Add(model);
                }

                return Ok(listModel);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("/selecionar/{id:int}")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public ActionResult<InterestModel> GetById(int id)
        {
            var interest = repository.GetById(id);

            try
            {
                if (interest == null) return NotFound();

                var model = new InterestModel();
                model.Id = interest.Id;
                model.Name = interest.Name;
                model.InitialValue = interest.InitialValue;
                model.FinalValue = interest.FinalValue;
                model.Time = interest.Time;

                return Ok(interest);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/adicionar")]
        public ActionResult<InterestModel> Post([FromBody] InterestModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var interest = new Interest(model.Id, model.Name, 
                                            model.FinalValue, model.InitialValue, model.Time);
                repository.Create(interest);
                return Ok(interest);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("/atualizar/{id:int}")]
        public ActionResult<InterestModel> Put(int id, [FromBody] InterestModel model)
        {
            var isExist = repository.IsExist(id);

            if (isExist == false) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var interest = new Interest(id, model.Name, 
                                            model.FinalValue, model.InitialValue, model.Time);
                repository.Update(interest);
                return Ok(interest);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/excluir/{id:int}")]
        public ActionResult<Interest> Delete(int id)
        {
            var interest = repository.GetById(id);

            if (interest == null) return NotFound();

            try
            {
                repository.Delete(interest);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        */
    }
}
