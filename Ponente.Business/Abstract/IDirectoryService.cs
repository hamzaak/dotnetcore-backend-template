using Ponente.Entity.Concrete;
using System.Collections.Generic;

namespace Ponente.Business.Abstract
{
    public interface IDirectoryService
    {
        Directory Get(int id);
        List<Directory> GetAll();
        Directory Add(Directory directory);
        Directory Update(Directory directory);
        void Delete(int id);
    }
}
