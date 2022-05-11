Alter procedure spDeleteEmployee
@Name varchar,
@id int
As
delete from employeee_payroll where Name=@Name and id=@id;