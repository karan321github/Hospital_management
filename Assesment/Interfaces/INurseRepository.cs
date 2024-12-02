using Assesment.ModelDto;
using Assesment.Models;

namespace Assesment.Interfaces
{
    public interface INurseRepository
    {
        
        public List<Nurse> GetAllNurses();
        public NurseDto GetNurseByEid(int Eid);    
        public bool IsNurseExist(int EId);
        public bool CheckByName(string name);
        public bool CreateNurse(Nurse nurse);
        public bool DeleteNurse(Nurse nurse);
        public bool save();

    }
}
