create procedure spGetAllEmployee
@Name varchar(200),
@Address varchar(200),
@Phone bigint,
@BasicPAy float,
@Gender char(1)
AS
  insert into employeee_payroll(Name,Address,phone,BasicPay,Gender) values(@Name,@Address,@Phone,@BasicPay,@Gender);
