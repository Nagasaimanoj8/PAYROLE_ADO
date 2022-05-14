create procedure spInsertIntoTwoTable
(
@Name varchar(200),
@Address varchar(200),
@id int OUTPUT,
@Gender char(1)
)
As
insert into employeee_payroll(Name,Address,Gender)values(@Name,@Address,@Gender);
set @id=SCOPE_IDENTITY()
RETURN @id;
insert into employeee_payroll(Name,Address,Gender)values('TestEmp','Bnglr','F');
