create procedure spUpdateEmployee
@Name varchar(200),
@id int,
@BasicPAy float
AS
 Update employeee_payroll set BasicPay=@BasicPAy where Name=@Name and id=@id;