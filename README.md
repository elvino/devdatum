# devdatum

Passos para Execução:

1 - Clone

git clone https://github.com/elvino/devdatum.git

2 - Abrir pasta cd "/Devdatum/DevDatum"

3 - Executar no Docker

3.1 - docker build -f "../DevDatum/Dockerfile" --force-rm -t devdatum:latest --target base  "." (nome da imagem pode ser modificada)

5.2 - docker run --rm -d  -p 80:80/tcp devdatum:latest (porta pode ser alterada)

4 - Executar no IIS

4.1 - dotnet build
4.2 - dotnet run

5 - Executar Tests

5.1 - dotnet build
5.2 - dotnet tests
