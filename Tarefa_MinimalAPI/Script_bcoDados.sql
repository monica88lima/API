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
