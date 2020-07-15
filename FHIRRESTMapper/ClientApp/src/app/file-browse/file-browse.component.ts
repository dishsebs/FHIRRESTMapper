import { Component, ViewChild  } from '@angular/core';
import { DataService } from "../shared/data.service";

@Component({
  selector: 'app-file-browse',
  templateUrl: './file-browse.component.html',
  styleUrls: ['./file-browse.component.css']
})
export class FileBrowseComponent {
  @ViewChild('fileInput', { static: false })
  fileInput;

  file: File | null = null;

  constructor(private fileData: DataService) { }

  onClickFileInputButton(): void {
    this.fileInput.nativeElement.click();
  }

  onChangeFileInput(): void {
    const files: { [key: string]: File } = this.fileInput.nativeElement.files;
    this.file = files[0];
    this.fileData.changeRestFile(this.file);
    console.log('Browsed File Name onChangeFileInput: ' + this.file.name);
  }
}
