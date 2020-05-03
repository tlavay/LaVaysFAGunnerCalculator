import { Component } from '@angular/core';
import { GunneryApi } from '../services/gunnery-api.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private result: string;

  constructor(private gunneryApi: GunneryApi) { }
  ngOnInit() {
    this.gunneryApi.getTest().subscribe(result => {
      this.result = result;
    });
  }
}
