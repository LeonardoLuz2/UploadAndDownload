import { Component, OnInit } from '@angular/core';
import { UploadService } from '../shared/upload.service';
import { HttpEventType } from '@angular/common/http';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.css']
})
export class UploadFileComponent implements OnInit {
  progress: number;
  message: string;
  invalidFile: boolean;

  constructor(private uploadService: UploadService) { }

  ngOnInit() {
  }

  upload(file) {
    this.invalidFile = false;

    if (file.length == 0) {
      this.invalidFile = true;
      return;
    }

    if (file.size > 5000000) {
      this.invalidFile = true;
      return;
    }

    this.uploadService.uploadFile(file).subscribe(
      event => {
        if (event.type === HttpEventType.UploadProgress) {
          this.progress = Math.round(100 * event.loaded / event.total);
        } else if (event.type === HttpEventType.Response) {
          this.message = event.body.message;
        }
      },
      error => {
        console.error(error);
      }
    );
  }

}
