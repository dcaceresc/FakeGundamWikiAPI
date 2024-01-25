import { Component, OnInit, inject, signal } from '@angular/core';
import { TableComponent } from '../../shared/components/table/table.component';
import { NotificationService } from '../../core/services/notification.service';

@Component({
  standalone: true,
  imports: [TableComponent],
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.scss'
})
export class DashboardComponent implements OnInit{

  public notificationService = inject(NotificationService);

  public data = signal<any[]>([]);
  public columns:any[] = [];


  ngOnInit(): void {
    this.columns = [
      {key: 'id', name : '#'},
      {key: 'firstName', name : 'First name'},
      {key: 'lastName', name: "Last name"},
      {key: 'position', name: "Position"},
      {key: 'office', name: "Office"},
      {key: 'age', name: "Age"},
      {key: 'startDate', name : "Start date"},
      {key: 'salary', name : "Salary"},
      {key: 'extn', name : "Extn."},
      {key: 'email', name : "E-mail"}
    ]  

    this.data.set([
      { id: 1, firstName: 'Tiger', lastName: 'Nixon', position: 'System Architect', office: 'Edinburgh', age: 61, startDate: '2011-04-25', salary: '$320,800', extn: 5421, email: 't.nixon@datatables.net' },
      { id: 2, firstName: 'Garrett', lastName: 'Winters', position: 'Accountant', office: 'Tokyo', age: 63, startDate: '2011-07-25', salary: '$170,750', extn: 8422, email: 'g.winters@datatables.net' },
      { id: 3, firstName: 'Ashton', lastName: 'Cox', position: 'Junior Technical Author', office: 'San Francisco', age: 66, startDate: '2009-01-12', salary: '$86,000', extn: 1562, email: 'a.cox@datatables.net' },
      { id: 4, firstName: 'Cedric', lastName: 'Kelly', position: 'Senior Javascript Developer', office: 'Edinburgh', age: 22, startDate: '2012-03-29', salary: '$433,060', extn: 6224, email: 'c.kelly@datatables.net' },
      { id: 5, firstName: 'Airi', lastName: 'Satou', position: 'Accountant', office: 'Tokyo', age: 33, startDate: '2008-11-28', salary: '$162,700', extn: 5407, email: 'a.satou@datatables.net' },
      { id: 6, firstName: 'Brielle', lastName: 'Williamson', position: 'Integration Specialist', office: 'New York', age: 61, startDate: '2012-12-02', salary: '$372,000', extn: 4804, email: 'b.williamson@datatables.net' },
      { id: 7, firstName: 'Herrod', lastName: 'Chandler', position: 'Sales Assistant', office: 'San Francisco', age: 59, startDate: '2012-08-06', salary: '$137,500', extn: 9608, email: 'h.chandler@datatables.net' },
      { id: 8, firstName: 'Rhona', lastName: 'Davidson', position: 'Integration Specialist', office: 'Tokyo', age: 55, startDate: '2010-10-14', salary: '$327,900', extn: 6200, email: 'r.davidson@datatables.net' },
      { id: 9, firstName: 'Colleen', lastName: 'Hurst', position: 'Javascript Developer', office: 'San Francisco', age: 39, startDate: '2009-09-15', salary: '$205,500', extn: 2360, email: 'c.hurst@datatables.net' },
      { id: 10, firstName: 'Sonya', lastName: 'Frost', position: 'Software Engineer', office: 'Edinburgh', age: 23, startDate: '2008-12-13', salary: '$103,600', extn: 1667, email: 's.frost@datatables.net' },
      { id: 11, firstName: 'Jena', lastName: 'Gaines', position: 'Office Manager', office: 'London', age: 30, startDate: '2008-12-19', salary: '$90,560', extn: 3814, email: 'j.gaines@datatables.net' },
      { id: 12, firstName: 'Quinn', lastName: 'Flynn', position: 'Support Lead', office: 'Edinburgh', age: 22, startDate: '2013-03-03', salary: '$342,000', extn: 9497, email: 'q.flynn@datatables.net' },
      { id: 13, firstName: 'Charde', lastName: 'Marshall', position: 'Regional Director', office: 'San Francisco', age: 36, startDate: '2008-10-16', salary: '$470,600', extn: 6741, email: 'c.marshall@datatables.net' },
      { id: 14, firstName: 'Haley', lastName: 'Kennedy', position: 'Senior Marketing Designer', office: 'London', age: 43, startDate: '2012-12-18', salary: '$313,500', extn: 3597, email: 'h.kennedy@datatables.net' },
      { id: 15, firstName: 'Tatyana', lastName: 'Fitzpatrick', position: 'Regional Director', office: 'London', age: 19, startDate: '2010-03-17', salary: '$385,750', extn: 1965, email: 't.fitzpatrick@datatables.net' },
      { id: 16, firstName: 'Michael', lastName: 'Silva', position: 'Marketing Designer', office: 'London', age: 66, startDate: '2012-11-27', salary: '$198,500', extn: 1581, email: 'm.silva@datatables.net' },
      { id: 17, firstName: 'Paul', lastName: 'Byrd', position: 'Chief Financial Officer (CFO)', office: 'New York', age: 64, startDate: '2010-06-09', salary: '$725,000', extn: 3059, email: 'p.byrd@datatables.net' },
      { id: 18, firstName: 'Gloria', lastName: 'Little', position: 'Systems Administrator', office: 'New York', age: 59, startDate: '2009-04-10', salary: '$237,500', extn: 1721, email: 'g.little@datatables.net' },
      { id: 19, firstName: 'Bradley', lastName: 'Greer', position: 'Software Engineer', office: 'London', age: 41, startDate: '2012-10-13', salary: '$132,000', extn: 2558, email: 'b.greer@datatables.net' },
      { id: 20, firstName: 'Dai', lastName: 'Rios', position: 'Personnel Lead', office: 'Edinburgh', age: 35, startDate: '2012-09-26', salary: '$217,500', extn: 2290, email: 'd.rios@datatables.net' },
      { id: null, firstName: 'Yuri', lastName: 'Berry', position: 'Chief Marketing Officer (CMO)', office: 'New York', age: 40, startDate: '2009-06-25', salary: '$675,000', extn: 6154, email: 'y.berry@datatables.net' },
      { id: null, firstName: 'Caesar', lastName: 'Vance', position: 'Pre-Sales Support', office: 'New York', age: 21, startDate: '2011-12-12', salary: '$106,450', extn: 8330, email: 'c.vance@datatables.net' },
      { id: null, firstName: 'Doris', lastName: 'Wilder', position: 'Sales Assistant', office: 'Sydney', age: 23, startDate: '2010-09-20', salary: '$85,600', extn: 3023, email: 'd.wilder@datatables.net' },
      { id: null, firstName: 'Angelica', lastName: 'Ramos', position: 'Chief Executive Officer (CEO)', office: 'London', age: 47, startDate: '2009-10-09', salary: '$1,200,000', extn: 5797, email: 'a.ramos@datatables.net' },
      { id: null, firstName: 'Gavin', lastName: 'Joyce', position: 'Developer', office: 'Edinburgh', age: 42, startDate: '2010-12-22', salary: '$92,575', extn: 8822, email: 'g.joyce@datatables.net' },
      { id: null, firstName: 'Jennifer', lastName: 'Chang', position: 'Regional Director', office: 'Singapore', age: 28, startDate: '2010-11-14', salary: '$357,650', extn: 9239, email: 'j.chang@datatables.net' },
      { id: null, firstName: 'Brenden', lastName: 'Wagner', position: 'Software Engineer', office: 'San Francisco', age: 28, startDate: '2011-06-07', salary: '$206,850', extn: 1314, email: 'b.wagner@datatables.net' },
      { id: null, firstName: 'Fiona', lastName: 'Green', position: 'Chief Operating Officer (COO)', office: 'San Francisco', age: 48, startDate: '2010-03-11', salary: '$850,000', extn: 2947, email: 'f.green@datatables.net' },
      { id: null, firstName: 'Shou', lastName: 'Itou', position: 'Regional Marketing', office: 'Tokyo', age: 20, startDate: '2011-08-14', salary: '$163,000', extn: 8899, email: 's.itou@datatables.net' },
      { id: null, firstName: 'Michelle', lastName: 'House', position: 'Integration Specialist', office: 'Sydney', age: 37, startDate: '2011-06-02', salary: '$95,400', extn: 2769, email: 'm.house@datatables.net' },
      { id: null, firstName: 'Suki', lastName: 'Burks', position: 'Developer', office: 'London', age: 53, startDate: '2009-10-22', salary: '$114,500', extn: 6832, email: 's.burks@datatables.net' },
  { id: null, firstName: 'Prescott', lastName: 'Bartlett', position: 'Technical Author', office: 'London', age: 27, startDate: '2011-05-07', salary: '$145,000', extn: 3606, email: 'p.bartlett@datatables.net' },
  { id: null, firstName: 'Gavin', lastName: 'Cortez', position: 'Team Leader', office: 'San Francisco', age: 22, startDate: '2008-10-26', salary: '$235,500', extn: 2860, email: 'g.cortez@datatables.net' },
  { id: null, firstName: 'Martena', lastName: 'Mccray', position: 'Post-Sales support', office: 'Edinburgh', age: 46, startDate: '2011-03-09', salary: '$324,050', extn: 8240, email: 'm.mccray@datatables.net' },
  { id: null, firstName: 'Unity', lastName: 'Butler', position: 'Marketing Designer', office: 'San Francisco', age: 47, startDate: '2009-12-09', salary: '$85,675', extn: 5384, email: 'u.butler@datatables.net' },
  { id: null, firstName: 'Howard', lastName: 'Hatfield', position: 'Office Manager', office: 'San Francisco', age: 51, startDate: '2008-12-16', salary: '$164,500', extn: 7031, email: 'h.hatfield@datatables.net' },
  { id: null, firstName: 'Hope', lastName: 'Fuentes', position: 'Secretary', office: 'San Francisco', age: 41, startDate: '2010-02-12', salary: '$109,850', extn: 6318, email: 'h.fuentes@datatables.net' },
  { id: null, firstName: 'Vivian', lastName: 'Harrell', position: 'Financial Controller', office: 'San Francisco', age: 62, startDate: '2009-02-14', salary: '$452,500', extn: 9422, email: 'v.harrell@datatables.net' },
  { id: null, firstName: 'Timothy', lastName: 'Mooney', position: 'Office Manager', office: 'London', age: 37, startDate: '2008-12-11', salary: '$136,200', extn: 7580, email: 't.mooney@datatables.net' },
  { id: null, firstName: 'Jackson', lastName: 'Bradshaw', position: 'Director', office: 'New York', age: 65, startDate: '2008-09-26', salary: '$645,750', extn: 1042, email: 'j.bradshaw@datatables.net' },
  { id: null, firstName: 'Olivia', lastName: 'Liang', position: 'Support Engineer', office: 'Singapore', age: 64, startDate: '2011-02-03', salary: '$234,500', extn: 2120, email: 'o.liang@datatables.net' },
  { id: null, firstName: 'Bruno', lastName: 'Nash', position: 'Software Engineer', office: 'London', age: 38, startDate: '2011-05-03', salary: '$163,500', extn: 6222, email: 'b.nash@datatables.net' },
  { id: null, firstName: 'Sakura', lastName: 'Yamamoto', position: 'Support Engineer', office: 'Tokyo', age: 37, startDate: '2009-08-19', salary: '$139,575', extn: 9383, email: 's.yamamoto@datatables.net' },
  { id: null, firstName: 'Thor', lastName: 'Walton', position: 'Developer', office: 'New York', age: 61, startDate: '2013-08-11', salary: '$98,540', extn: 8327, email: 't.walton@datatables.net' },
  { id: null, firstName: 'Finn', lastName: 'Camacho', position: 'Support Engineer', office: 'San Francisco', age: 47, startDate: '2009-07-07', salary: '$87,500', extn: 2927, email: 'f.camacho@datatables.net' },
  { id: null, firstName: 'Serge', lastName: 'Baldwin', position: 'Data Coordinator', office: 'Singapore', age: 64, startDate: '2012-04-09', salary: '$138,575', extn: 8352, email: 's.baldwin@datatables.net' },
  { id: null, firstName: 'Zenaida', lastName: 'Frank', position: 'Software Engineer', office: 'New York', age: 63, startDate: '2010-01-04', salary: '$125,250', extn: 7439, email: 'z.frank@datatables.net' },
  { id: null, firstName: 'Zorita', lastName: 'Serrano', position: 'Software Engineer', office: 'San Francisco', age: 56, startDate: '2012-06-01', salary: '$115,000', extn: 4389, email: 'z.serrano@datatables.net' },
  { id: null, firstName: 'Jennifer', lastName: 'Acosta', position: 'Junior Javascript Developer', office: 'Edinburgh', age: 43, startDate: '2013-02-01', salary: '$75,650', extn: 3431, email: 'j.acosta@datatables.net' },
  { id: null, firstName: 'Cara', lastName: 'Stevens', position: 'Sales Assistant', office: 'New York', age: 46, startDate: '2011-12-06', salary: '$145,600', extn: 3990, email: 'c.stevens@datatables.net' },
  { id: null, firstName: 'Hermione', lastName: 'Butler', position: 'Regional Director', office: 'London', age: 47, startDate: '2011-03-21', salary: '$356,250', extn: 1016, email: 'h.butler@datatables.net' },
  { id: null, firstName: 'Lael', lastName: 'Greer', position: 'Systems Administrator', office: 'London', age: 21, startDate: '2009-02-27', salary: '$103,500', extn: 6733, email: 'l.greer@datatables.net' },
  { id: null, firstName: 'Jonas', lastName: 'Alexander', position: 'Developer', office: 'San Francisco', age: 30, startDate: '2010-07-14', salary: '$86,500', extn: 8196, email: 'j.alexander@datatables.net' },
  { id: null, firstName: 'Shad', lastName: 'Decker', position: 'Regional Director', office: 'Edinburgh', age: 51, startDate: '2008-11-13', salary: '$183,000', extn: 6373, email: 's.decker@datatables.net' },
  { id: null, firstName: 'Michael', lastName: 'Bruce', position: 'Javascript Developer', office: 'Singapore', age: 29, startDate: '2011-06-27', salary: '$183,000', extn: 5384, email: 'm.bruce@datatables.net' },
  { id: null, firstName: 'Donna', lastName: 'Snider', position: 'Customer Support', office: 'New York', age: 27, startDate: '2011-01-25', salary: '$112,000', extn: 4226, email: 'd.snider@datatables.net' }
    ]);
  }

  ToastSuccess(title:string, message:string) {
    this.notificationService.showSuccess(title, message);
  }
  
  ToastError(title:string, message:string) {
    this.notificationService.showError(title, message);
  }
}
