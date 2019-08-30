using Ponente.Business.Abstract;
using Ponente.Data.Abstract;
using Ponente.Entity.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace Ponente.Business.Concrete
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IDirectoryRepository _directoryRepository;

        public DirectoryService(IDirectoryRepository directoryRepository)
        {
            _directoryRepository = directoryRepository;
        }

        public Directory Add(Directory directory)
        {
            return _directoryRepository.Add(directory);
        }

        public void Delete(int id)
        {
            var directory = Get(id);
            _directoryRepository.Delete(directory);
        }

        public Directory Get(int id)
        {
            return _directoryRepository.Get(x => x.Id == id);
        }

        public List<Directory> GetAll()
        {
            return _directoryRepository.GetList()
                .OrderBy(x=> x.Name)
                .ToList();
        }

        public Directory Update(Directory directory)
        {
            return _directoryRepository.Update(directory);
        }
    }
}
