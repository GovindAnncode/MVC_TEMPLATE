using MVC_TEMPLATE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TEMPLATE.Controllers
{
    public interface IConfigService
    {
        List<MenuItems> Menu();
        void AddUpdateMenu(List<MenuItems> newData);
        void DeleteSection(MenuItems newData);

        List<Rules> Rules();
        void AddUpdateRules(List<Rules> newData);
        void DeleteRule(Rules newData);

        List<Welcome_Banner> Welcome_Banner();
        void AddUpdateWelcomeBanner(List<Welcome_Banner> newData);
        void DeleteWelcomeBanner(Welcome_Banner newData);

        Dictionary<string, string> Colors();
        void SaveColors(List<ColorConfigRequestDto> formData);

        List<return_reasons> return_reasons();
        void AddUpdateReturn_reasons(List<return_reasons> newData);
        void DeleteReturnReasons(return_reasons newData);

        List<SortCollection> SortCollection();
        void AddUpdateSortCollection(List<SortCollection> newData);
        void DeleteSortCollection(SortCollection newData);
    }
}
