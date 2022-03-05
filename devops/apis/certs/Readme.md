copiar o pfx que esta na pasta:

%USERPROFILE%\.aspnet\https

caso não exista rodar os comandos:

https -ep $env:USERPROFILE\.aspnet\https\aspnetapp.pfx -p devcertpass

New-SelfSignedCertificate -DnsName *.dellpreto, localhost -CertStoreLocation cert:\LocalMachine\My

New-SelfSignedCertificate -DnsName dellpreto, localhost -CertStoreLocation cert:\LocalMachine\My

exportar o certificado cer e pfx