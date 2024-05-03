#Generates code for a DbContext and entity types for a database
#For Azure SqlServer
#Scaffold-DbContext 'Data Source=fs-devdb.database.windows.net;Initial Catalog=BS_OE_Budget;Integrated Security=False;User ID=usr_chansak;Password=1q2w#E$R;Min Pool Size=10;Max Pool Size=200;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/DB -ContextDir Models/Context -DataAnnotations -f
#For Local
#Scaffold-DbContext "Server=.\SQLEXPRESS03;Database=BS_OE_Budget;Trusted_Connection=True;MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models/DB -ContextDir Models/Context -DataAnnotations -f