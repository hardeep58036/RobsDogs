using System.Web.Mvc;
using Ui.Services;
using Ui.ViewModelMappers;

/*
 * 1) I injected the service to controller instead of into the mapper as it is more cleaner this way
 * */
namespace Ui.Controllers
{
    public class RobsDogsController : Controller
    {
        private readonly IDogOwnerViewModelMapper _mapper;
        private readonly IDogOwnerService _service;

        public RobsDogsController(IDogOwnerViewModelMapper mapper, IDogOwnerService service)
        {
            _mapper = mapper;
            _service = service;

        }

        // GET: RobsDogs
        public ActionResult Index()
        {
            var dogOwnerListViewModel = _mapper.MapDogOwners(_service.GetAllDogOwners());
            return View(dogOwnerListViewModel);
        }
    }
}