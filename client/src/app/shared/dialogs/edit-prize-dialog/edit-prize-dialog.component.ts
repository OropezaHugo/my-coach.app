import {Component, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {PrizeModel} from '../../../models/prize.models';
import {PrizesService} from '../../../services/prizes.service';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatButton, MatFabButton} from '@angular/material/button';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatIcon} from '@angular/material/icon';
import {MatInput} from '@angular/material/input';

@Component({
  selector: 'app-edit-prize-dialog',
  imports: [
    MatButton,
    MatDialogContent,
    MatFabButton,
    MatFormField,
    MatIcon,
    MatInput,
    MatLabel,
    ReactiveFormsModule
  ],
  templateUrl: './edit-prize-dialog.component.html',
  styleUrl: './edit-prize-dialog.component.scss'
})
export class EditPrizeDialogComponent {
  dialogRef = inject(MatDialogRef<EditPrizeDialogComponent>);
  data = inject<PrizeModel>(MAT_DIALOG_DATA);
  prizeService = inject(PrizesService)
  image64?: string = this.data.prizeImage;
  fileName?: string = this.data.prizeName;
  convertToBase64(event: any) {
    const file = event.target.files[0]
    if (file) {
      const validExtensions = ['image/png', 'image/jpeg'];
      if (!validExtensions.includes(file.type)) {
        console.log(file);
        alert(`Formato no válido. Solo se permiten archivos .png y .jpg ${file.type}`);
        return;
      }
      this.fileName = file.name;
      const reader = new FileReader();
      reader.onload = () => {
        this.image64 = (reader.result as string).split(',')[1];
      };
      reader.readAsDataURL(file);
    }
    return;
  }
  updatePrizeForm = new FormGroup({
    prizeName: new FormControl<string>(this.data.prizeName, [Validators.required]),
    prizePoints: new FormControl<number>(this.data.points, [Validators.required]),
  })

  updatePrize(){
    if (this.updatePrizeForm.value.prizeName !== undefined
      && this.updatePrizeForm.value.prizeName !== null
      && this.updatePrizeForm.value.prizePoints !== undefined
      && this.updatePrizeForm.value.prizePoints !== null
      && this.image64 !== undefined
      && this.updatePrizeForm.valid) {
      this.prizeService.updatePrizeById(this.data.id, {
        prizeName: this.updatePrizeForm.value.prizeName,
        points: this.updatePrizeForm.value.prizePoints,
        prizeImage: this.image64
      }).subscribe({
        next: () => {
          this.dialogRef.close()
        }
      })
    }
  }
}
