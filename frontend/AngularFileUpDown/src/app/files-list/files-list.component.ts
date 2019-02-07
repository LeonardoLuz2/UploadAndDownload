import { Component, OnInit } from '@angular/core';
import { DownloadService } from '../shared/download.service';
import { Observable, interval } from 'rxjs';

intervalo: interval(200);

@Component({
  selector: 'app-files-list',
  templateUrl: './files-list.component.html',
  styleUrls: ['./files-list.component.css']
})
export class FilesListComponent implements OnInit {
  
  files$: Observable<string[]>;

  constructor(private downloadService: DownloadService) { }

  ngOnInit() {
      this.getFiles();
  }

  getFiles() {
    this.files$ = this.downloadService.getFiles();
  }

  downloadFile(fileName) {
    this.downloadService.downloadFile(fileName).subscribe(
      (response) => {
        const element = document.createElement('a');
        element.href = URL.createObjectURL(response);
        element.download = fileName;
        document.body.appendChild(element);
        element.click();
      },
      (error) => console.error(error)
    );
  }
}
