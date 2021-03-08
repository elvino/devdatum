# devdatum

Passos para Execução:

1 - Clone

git clone https://github.com/elvino/devdatum.git

2 - Abrir pasta cd "/Devdatum/DevDatum"

3 - Executar no Docker

docker build -f "../DevDatum/Dockerfile" --force-rm -t devdatum:latest --target base  "." (nome da imagem pode ser modificada)

docker run --rm -d  -p 80:80/tcp devdatum:latest (porta pode ser alterada)

4 - Executar no IIS

dotnet build
dotnet run

5 - Executar Tests

dotnet build
dotnet tests
