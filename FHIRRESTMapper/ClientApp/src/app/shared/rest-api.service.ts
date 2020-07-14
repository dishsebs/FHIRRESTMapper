import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class RestApiService {
  apiURLPrefix: string;
  asyncResult: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.apiURLPrefix = baseUrl;
  }

  // Http Options
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  // HttpClient API get() method => Fetch REST Model
  async getRestModel() {
    this.asyncResult = await this.http.get(this.apiURLPrefix + 'api/RestModel').toPromise();
    //console.log('asyncResult : ' + JSON.stringify(this.asyncResult));
    return this.asyncResult;
  }

  //getRestModel(): Observable<any> {
  //  return this.http
  //    .get(this.apiURLPrefix + 'api/RestModel')
  //    .pipe(map((response: Response) => {
  //      return response.json();
  //    }));
  //}

  // HttpClient API get() method => Fetch employee
  //getEmployee(id): Observable<Employee> {
  //  return this.http.get<Employee>(this.apiURL + '/employees/' + id)
  //    .pipe(
  //      retry(1),
  //      catchError(this.handleError)
  //    )
  //}

  // HttpClient API post() method => Create employee
  //createEmployee(employee): Observable<Employee> {
  //  return this.http.post<Employee>(this.apiURL + '/employees', JSON.stringify(employee), this.httpOptions)
  //    .pipe(
  //      retry(1),
  //      catchError(this.handleError)
  //    )
  //}

  // HttpClient API put() method => Update employee
  //updateEmployee(id, employee): Observable<Employee> {
  //  return this.http.put<Employee>(this.apiURL + '/employees/' + id, JSON.stringify(employee), this.httpOptions)
  //    .pipe(
  //      retry(1),
  //      catchError(this.handleError)
  //    )
  //}

  // HttpClient API delete() method => Delete employee
  //deleteEmployee(id) {
  //  return this.http.delete<Employee>(this.apiURL + '/employees/' + id, this.httpOptions)
  //    .pipe(
  //      retry(1),
  //      catchError(this.handleError)
  //    )
  //}

  // Error handling 
  handleError(error) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = 'Error Code: ${error.status}\nMessage: ${error.message}';
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }

}
