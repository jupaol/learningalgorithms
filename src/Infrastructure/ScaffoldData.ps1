dotnet ef dbcontext scaffold `
	"Data Source=.;Database=[DB_HERE];Integrated Security=true;" `
	Microsoft.EntityFrameworkCore.SqlServer `
	--use-database-names --output-dir Data\Models --context-dir Data --data-annotations --force
