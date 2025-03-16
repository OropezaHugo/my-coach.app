import {Component, inject} from '@angular/core';
import {PrizesService} from '../../../services/prizes.service';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodToFoodGroupData} from '../../../models/diet.models';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatButton, MatFabButton, MatIconButton} from '@angular/material/button';
import {MatIcon} from '@angular/material/icon';

@Component({
  selector: 'app-add-prize-dialog',
  imports: [
    MatDialogContent,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule,
    MatButton,
    MatIconButton,
    MatIcon,
    MatFabButton
  ],
  templateUrl: './add-prize-dialog.component.html',
  styleUrl: './add-prize-dialog.component.scss'
})
export class AddPrizeDialogComponent {
  dialogRef = inject(MatDialogRef<AddPrizeDialogComponent>);
  data = inject<AddFoodToFoodGroupData>(MAT_DIALOG_DATA);
  prizeService = inject(PrizesService)
  image64?: string;
  fileName?: string;
  addPrizeForm = new FormGroup({
    prizeName: new FormControl<string>('', [Validators.required]),
    prizePoints: new FormControl<number>(0, [Validators.required]),
  })
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
  createPrize(){
    if (this.addPrizeForm.value.prizeName !== undefined
    && this.addPrizeForm.value.prizeName !== null
    && this.addPrizeForm.value.prizePoints !== undefined
    && this.addPrizeForm.value.prizePoints !== null
    && this.image64 !== undefined
    && this.addPrizeForm.valid) {
      this.prizeService.createPrize({
        prizeName: this.addPrizeForm.value.prizeName,
        points: this.addPrizeForm.value.prizePoints,
        prizeImage: this.image64
      }).subscribe({
        next: () => {
          this.dialogRef.close()
        }
      })
    }
  }
}
