using OpenableProject.Models;
using OpenableProject.Storage;

namespace OpenableProject.Repositories;

public class VendorRepository
{
    public List<Vendor> GetAll()
    {
        return VendorStorage.GetAll();
    }
}