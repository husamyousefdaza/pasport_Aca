//import axios from 'axios';
import securityService from './SecurityService.js';
import DashboardService from './DashboardService.js';
import TransactionsService from './TransactionsService.js';
import AdministratorsService from './AdministratorsService';

export default {

    // ...securityService,
    securityService: securityService,
    DashboardService: DashboardService,
    TransactionsService: TransactionsService,
    AdministratorsService: AdministratorsService,

}