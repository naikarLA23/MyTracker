1. packages to install:

	dotnet tool install --global dotnet-ef

	Microsoft.EntityFrameworkCore - 7.0.20
	Microsoft.EntityFrameworkCore.Design - 7.0.20
	Microsoft.EntityFrameworkCore.SqlServer - 7.0.20
	Microsoft.EntityFrameworkCore.Tools - 7.0.20


2. Scaffold Command

 Scaffold-DbContext "Server=ANAND_LAPTOP;Database=ExpenseManagement; Integrated Security=True;Encrypt=false;" 
 Microsoft.EntityFrameworkCore.SqlServer 
 -OutputDir Model\EntityModel -ContextDir Model\EntityModel\Context -Context ExpenseManagementContext