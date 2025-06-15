import { Component, EventEmitter, Output } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-upload-form',
  templateUrl: './upload-form.component.html'
})
export class UploadFormComponent {
  @Output() uploaded = new EventEmitter<void>();

  constructor(private http: HttpClient) { }

  onFileSelected(event: any) {
    const file: File = event.target.files[0];
    if (file) {
      const formData = new FormData();
      formData.append('file', file);
      this.http.post('/api/files/upload', formData).subscribe(() => this.uploaded.emit());
    }
  }
}
