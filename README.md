<h1 align="center">:computer: #API</h1>

:heavy_check_mark: **API.Catalogo**
:heavy_check_mark: **Minimal.API**

#:open_file_folder:-[Arquitetura](#arquitetura)

Os projetos deste repositorio foram criados com base nos princípios e conceitos apresentados no livro :blue_book: "Clean Architecture" **(Arquitetura Limpa) de Robert C. Martin.** 
Esta arquitetura visa promover a organização, a escalabilidade e a manutenibilidade do código, seguindo as diretrizes propostas pelo autor.


#:pushpin:-[Recursos](#recursos)

Visual Studio;
MySql Workbench;


#-[Pré-requisitos](#pré-requisitos)

Versão .NET Core;
Microsoft.EntityFramewrkCore.Design;
Microsoft.EntityFramewrkCore.Tools;
Pomelo.Microsoft.EntityFramewrkCore.MySql;



#-[Instalação](#instalação)
Abra com o Visual Studio a Solution Catalogo_Api_v1;
Configure a string de conexão com os dados adequados ao banco de dados de escolha.


#Edite o arquivo appsettings.json

   ```bash
  "ConnectionStrings": {
  "DefaultConnection": "Server=127.0.0.1;Database=CatalogoDB;Uid=root;Pwd=root;"
   ```
#No Menu selecione :
  Ferramentas / Gerenciador de Pacotes NuGet 
     -> Console de Gerenciador de Pacotes
       
Execute o comando abaixo para criar o banco de dados e as tabelas:


  ```bash
  add-migration Initial

  update-database
   ```


> [!NOTE]
> Material de Estudo - Curso Web API ASP .NET Core Essencial (.NET 6) com Professor Macoratti
Curso Udemy .
