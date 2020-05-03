import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class GunneryApi {
  private armBaseUrl = '/api/gunnery';
  constructor(private http: HttpClient) { }

  getTest() {
    return this.http.get<any>(`${this.armBaseUrl}/test`);
  }
}
