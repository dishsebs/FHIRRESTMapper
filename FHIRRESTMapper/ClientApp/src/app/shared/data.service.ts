import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private fileSource = new BehaviorSubject('File Name');
  currentFile = this.fileSource.asObservable();

  constructor() { }

  changeRestFile(file: File) {
    this.fileSource.next(file.name);
  }
}
