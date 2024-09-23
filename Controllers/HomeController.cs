// HomeController.cs
using Microsoft.AspNetCore.Mvc;
using C_Hero.Services;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using C_Hero.Models.Entities;

namespace C_Hero.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRapportService _rapportService;
        private readonly IDisputeService _disputeService;
        private readonly IMissionService _missionService;
        private readonly ICivilService _civilService;
        private readonly IOrgaService _orgaService;
        private readonly ISuperHeroService _superHeroService;
        private readonly ICrisisService _crisisService;
        private readonly IIncidentService _incidentService;
        private readonly ISuperVillainService _superVillainService;

        public HomeController(IRapportService rapportService, IDisputeService disputeService,
            IMissionService missionService, ICivilService civilService, IOrgaService orgaService,
            ISuperHeroService superHeroService, ICrisisService crisisService, ISuperVillainService
            supervillainService, IIncidentService incidentService)
        {
            _rapportService = rapportService;
            _disputeService = disputeService;
            _missionService = missionService;
            _civilService = civilService;
            _orgaService = orgaService;
            _superHeroService = superHeroService;
            _crisisService = crisisService;
            _incidentService = incidentService;
            _superVillainService = supervillainService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LoadTable(string table)
        {
            switch (table)
            {
                case "Rapports":
                    var rapports = await _rapportService.GetAllRapportsAsync();
                    return PartialView("RapportsPartial", rapports);
                case "Disputes":
                    var disputes = await _disputeService.GetAllDisputesAsync();
                    return PartialView("DisputesPartial", disputes);
                case "Missions":
                    var missions = await _missionService.GetAllMissionsAsync();
                    return PartialView("MissionsPartial", missions);
                case "Civils":
                    var civils = await _civilService.GetAllCivilsAsync();
                    return PartialView("CivilsPartial", civils);
                case "Orgas":
                    var orgas = await _orgaService.GetAllOrgasAsync();
                    return PartialView("OrgasPartial", orgas);
                case "SuperHeroes":
                    var superHeroes = await _superHeroService.GetAllSuperHeroesAsync();
                    return PartialView("SuperHeroesPartial", superHeroes);
                case "Crises":
                    var crises = await _crisisService.GetAllCrisesAsync();
                    return PartialView("CrisesPartial", crises);
                case "Incidents":
                    var incidents = await _incidentService.GetAllIncidentsAsync();
                    return PartialView("IncidentsPartial", incidents);
                case "SuperVillains":
                    var superVillains = await _superVillainService.GetAllSuperVillainsAsync();
                    return PartialView("SuperVillainsPartial", superVillains);

                default:
                    return BadRequest("Table inconnue");
            }
        }

        public async Task<IActionResult> Create(string table)
        {
            switch (table)
            {
                case "Rapports":
                    ViewBag.Civils = await _civilService.GetAllCivilsAsync();
                    ViewBag.Organisations = await _orgaService.GetAllOrgasAsync();
                    ViewBag.Missions = await _missionService.GetAllMissionsAsync();
                    ViewBag.Crises = await _crisisService.GetAllCrisesAsync();
                    ViewBag.SuperHeroes = await _superHeroService.GetAllSuperHeroesAsync(); // Ajout de cette ligne
                    return View("CreateRapport");
                case "Disputes":
                    ViewBag.Organisations = await _orgaService.GetAllOrgasAsync();
                    ViewBag.Civils = await _civilService.GetAllCivilsAsync();
                    return View("CreateDispute");
                case "Incidents":
                    ViewBag.Organisations = await _orgaService.GetAllOrgasAsync();
                    ViewBag.Civils = await _civilService.GetAllCivilsAsync();
                    ViewBag.SuperVillains = await _superVillainService.GetAllSuperVillainsAsync();
                    return View("CreateIncident");
                case "Orgas":
                    ViewBag.Civils = await _civilService.GetAllCivilsAsync();
                    ViewBag.SuperHeroes = await _superHeroService.GetAllSuperHeroesAsync();
                    ViewBag.SuperVillains = await _superVillainService.GetAllSuperVillainsAsync();
                    return View("CreateOrga");
                case "SuperHeroes":
                    ViewBag.Civils = await _civilService.GetAllCivilsAsync();
                    ViewBag.Orgas = await _orgaService.GetAllOrgasAsync();
                    return View("CreateSuperHero");
                case "Crises":
                    ViewBag.Disputes = await _disputeService.GetAllDisputesAsync();
                    ViewBag.Rapports = await _rapportService.GetAllRapportsAsync();
                    return View("CreateCrisis");
                // Ajoutez d'autres cas pour les autres tables
                default:
                    return Content("Table inconnue");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRapport(RapportModel model)
        {
            if (ModelState.IsValid)
            {
                await _rapportService.CreateRapportAsync(model);
                return RedirectToAction("Index");
            }
            // Recharger les listes en cas d'erreur de validation
            ViewBag.Civils = await _civilService.GetAllCivilsAsync();
            ViewBag.Organisations = await _orgaService.GetAllOrgasAsync();
            ViewBag.Missions = await _missionService.GetAllMissionsAsync();
            ViewBag.Crises = await _crisisService.GetAllCrisesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDispute(DisputeModel model)
        {
            if (ModelState.IsValid)
            {
                await _disputeService.CreateDisputeAsync(model);
                return RedirectToAction("Index");
            }
            // Recharger les listes en cas d'erreur de validation
            ViewBag.Organisations = await _orgaService.GetAllOrgasAsync();
            ViewBag.Civils = await _civilService.GetAllCivilsAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateIncident(IncidentModel model)
        {
            if (ModelState.IsValid)
            {
                await _incidentService.CreateIncidentAsync(model);
                return RedirectToAction("Index");
            }
            // Recharger les listes en cas d'erreur de validation
            ViewBag.Organisations = await _orgaService.GetAllOrgasAsync();
            ViewBag.Civils = await _civilService.GetAllCivilsAsync();
            ViewBag.SuperVillains = await _superVillainService.GetAllSuperVillainsAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrga(OrgaModel model)
        {
            if (ModelState.IsValid)
            {
                await _orgaService.CreateOrgaAsync(model);
                return RedirectToAction("Index");
            }
            ViewBag.Civils = await _civilService.GetAllCivilsAsync();
            ViewBag.SuperHeroes = await _superHeroService.GetAllSuperHeroesAsync();
            ViewBag.SuperVillains = await _superVillainService.GetAllSuperVillainsAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuperHero(SuperHeroModel model)
        {
            if (ModelState.IsValid)
            {
                await _superHeroService.CreateSuperHeroAsync(model);
                return RedirectToAction("Index");
            }
            // Recharger les listes en cas d'erreur de validation
            ViewBag.Civils = await _civilService.GetAllCivilsAsync();
            ViewBag.Orgas = await _orgaService.GetAllOrgasAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCrisis(CrisisModel model, List<Guid> Rapports)
        {
            if (ModelState.IsValid)
            {
                model.Rapports = new List<RapportModel>();
                foreach (var rapportId in Rapports)
                {
                    var rapport = await _rapportService.GetRapportByIdAsync(rapportId);
                    if (rapport != null)
                    {
                        model.Rapports.Add(rapport);
                    }
                }
                await _crisisService.CreateCrisisAsync(model);
                return RedirectToAction("Index");
            }
            // Recharger les listes en cas d'erreur de validation
            ViewBag.Disputes = await _disputeService.GetAllDisputesAsync();
            ViewBag.Rapports = await _rapportService.GetAllRapportsAsync();
            return View(model);
        }
    }
}
