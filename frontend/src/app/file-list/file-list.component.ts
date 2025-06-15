import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface FileItem {
  id: number;
  filename: string;
  size: number;
  uploadDate: string;
}

@Component({
  selector: 'app-file-list',
  templateUrl: './file-list.component.html'
})
export class FileListComponent implements OnInit {
  files: FileItem[] = [];

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.http.get<FileItem[]>('/api/files').subscribe(files => this.files = files);
  }

  delete(id: number) {
    this.http.delete(`/api/files/${id}`).subscribe(() => this.refresh());
  }

  download(id: number) {
    window.location.href = `/api/files/${id}/download`;
  }
}
