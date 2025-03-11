using OpenableProject.Models;
using OpenableProject.Storage;

namespace OpenableProject.Services;

public class VendorService
{
    public bool ValidAccount(string userAccount, string password)
    {
        var vendors = VendorStorage.GetAll();
        return vendors.Any(v => v.Account == userAccount && v.Password == password);
    }

    public Vendor GetVendor(string userAccount)
    {
       return VendorStorage.Get(userAccount);
    }
}