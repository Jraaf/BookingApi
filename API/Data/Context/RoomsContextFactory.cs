using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data.Context;

public class RoomsContextFactory : IDesignTimeDbContextFactory<RoomsContext>
{
    public RoomsContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<RoomsContext>();
        optionsBuilder.UseSqlServer("Server=localhost;Database=RoomsDb;User Id=sa;Password=12345");
        return new RoomsContext(optionsBuilder.Options);
    }
}