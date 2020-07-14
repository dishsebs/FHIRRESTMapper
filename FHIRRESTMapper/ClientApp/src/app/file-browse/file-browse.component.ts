import { Component, ViewChild } from '@angular/core';

@Component({
  selector: 'app-file-browse',
  templateUrl: './file-browse.component.html',
  styleUrls: ['./file-browse.component.css']
})
export class FileBrowseComponent {
  @ViewChild('fileInput', { static: false })
  fileInput;

  file: File | null = null;

  onClickFileInputButton(): void {
    this.fileInput.nativeElement.click();
  }

  onChangeFileInput(): void {
    const files: { [key: string]: File } = this.fileInput.nativeElement.files;
    this.file = files[0];
  }
}
