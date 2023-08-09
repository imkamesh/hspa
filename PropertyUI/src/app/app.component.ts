import { Component, OnInit } from '@angular/core';
import { PropertyService } from './services/property.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'PropertyUI';
  constructor(private propService: PropertyService) {}
  ngOnInit() {
    this.propService.getAllCities().subscribe((data) => {
      console.log(data);
    });
  }
}
