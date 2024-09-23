// HomeController.cs
using Microsoft.AspNetCore.Mvc;
using C_Hero.Services;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
    }
}
