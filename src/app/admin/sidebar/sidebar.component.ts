import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Event, NavigationEnd, ResolveEnd, Router } from '@angular/router';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
   url:string="";

  constructor(private router: Router) { }

  ngOnInit() {
    this.router.events.subscribe((data:Event) => {
      if(data.type==15){
        this.url=data.routerEvent.url;
      }
    });
  }
}
