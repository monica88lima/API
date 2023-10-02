# Minimal Api

**Simplicidade na construção da Api, elas utilizam menos recursos, sendo uma boa para implemntação de microserviços, pois possuem  o minimo de dependencia do ASP**

As rotas são configuradas na classe Program.cs

:point_right:Template API WEB do ASP .NET CORE/ Tirar a flag dos controladores  

:notebook:Documentação Disponivel https://learn.microsoft.com/pt-br/aspnet/core/tutorials/min-web-api?view=aspnetcore-7.0&tabs=visual-studio

Para instalar e utilizar:

Crie um banco de dados, a tabela Tarefas e insira algumas tarefas:

´´´bash
create database TarefasDB;

use TarefasDB;

Create Table Tarefas(
Id int Identity (1,1) Not Null,
Atividade nvarchar(255),
Status nvarchar(100),
)

Insert into Tarefas(Atividade, Status)
Values('tarefa 5','em andamento'),
      ('tarefa 2','em andamento'),
	  ('tarefa 3','concluida'),
	  ('tarefa 4','não iniciada');

´´´
