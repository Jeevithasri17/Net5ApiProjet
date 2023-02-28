CREATE procedure EmployeeDetails @empid uniqueidentifier
as 
begin
if @empid is not null
begin 

select e.Id as EmployeeID, e.Name as EmployeeName, e.Email as EmployeeMail, e.Phone as EmployeePhone, d.Id as DepartmentId, d.DeptName as DepartmentName 
from EmployeeDepartmentMapping ed
WITH (INDEX(index_EmployeeId))
inner join Employee e on e.Id = ed.EmpId
inner join Department d on d.Id = ed.DeptId
where e.Id = @empid
end

else 
begin
select 'Employee Id is null'
end
end