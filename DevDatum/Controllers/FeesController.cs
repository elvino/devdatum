using DevDatum.Domain.ContractRepositories;
using DevDatum.Domain.Entities;
using DevDatum.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DevDatum.Controllers
{
    [Route("v1/")]
    public class FeesController : ControllerBase
    {
        private readonly IFeesRepository repository;
        private readonly ILogger<FeesController> logger;

        public FeesController(IFeesRepository repository, ILogger<FeesController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        [Route("taxaJuros")]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public ActionResult<decimal> Fee()
        {
            try 
            {
                logger.LogInformation($"Informativo: Chamada Api Taxa de Juros Iniciada");

                var tax = new Fees().GetTaxFee;

                logger.LogInformation($"Informativo: Chamada Api Taxa de Juros Finalizada");

                return Ok(string.Format("{0:N2}", tax));
            }
            catch(Exception ex) 
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
        public ActionResult<List<FeesModel>> GetAll()
        {
            var fees = repository.GetAll();

            try
            {
                if (fees == null) return NotFound();

                var listModel = new List<FeesModel>();

                foreach (var fee in fees)
                {
                    var model = new FeesModel();
                    model.Id = fee.Id;
                    model.Name = fee.Name;
                    model.Fee = fee.Fee;

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
        public ActionResult<FeesModel> GetById(int id)
        {
            var fees = repository.GetById(id);

            try
            {
                if (fees == null) return NotFound();

                var model = new FeesModel();
                model.Id = fees.Id;
                model.Name = fees.Name;
                model.Fee = fees.Fee;
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("/adicionar")]
        public ActionResult<FeesModel> Post([FromBody] FeesModel model)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var fee = new Fees(model.Id, model.Name);
                repository.Create(fee);
                return Ok(fee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("/atualizar/{id:int}")]
        public ActionResult<FeesModel> Put(int id, [FromBody] FeesModel model)
        {
            var isExist = repository.IsExist(id);

            if (isExist == false) return NotFound();

            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var fee = new Fees(id, model.Name);
                repository.Update(fee);
                return Ok(fee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("/excluir/{id:int}")]
        public ActionResult<Fees> Delete(int id)
        {
            var fee = repository.GetById(id);

            if (fee == null) return NotFound();

            try
            {
                repository.Delete(fee);
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
