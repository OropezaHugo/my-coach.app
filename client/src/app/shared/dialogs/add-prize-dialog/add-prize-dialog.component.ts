import {Component, inject} from '@angular/core';
import {PrizesService} from '../../../services/prizes.service';
import {MAT_DIALOG_DATA, MatDialogContent, MatDialogRef} from '@angular/material/dialog';
import {AddFoodToFoodGroupData} from '../../../models/diet.models';
import {MatFormField, MatLabel} from '@angular/material/form-field';
import {MatInput} from '@angular/material/input';
import {FormControl, FormGroup, ReactiveFormsModule, Validators} from '@angular/forms';
import {MatButton} from '@angular/material/button';

@Component({
  selector: 'app-add-prize-dialog',
  imports: [
    MatDialogContent,
    MatLabel,
    MatFormField,
    MatInput,
    ReactiveFormsModule,
    MatButton
  ],
  templateUrl: './add-prize-dialog.component.html',
  styleUrl: './add-prize-dialog.component.scss'
})
export class AddPrizeDialogComponent {
  dialogRef = inject(MatDialogRef<AddPrizeDialogComponent>);
  data = inject<AddFoodToFoodGroupData>(MAT_DIALOG_DATA);
  prizeService = inject(PrizesService)
  addPrizeForm = new FormGroup({
    prizeName: new FormControl<string>('', [Validators.required]),
    prizePoints: new FormControl<number>(0, [Validators.required]),
  })
  createPrize(){
    if (this.addPrizeForm.value.prizeName !== undefined
    && this.addPrizeForm.value.prizeName !== null
    && this.addPrizeForm.value.prizePoints !== undefined
    && this.addPrizeForm.value.prizePoints !== null
    && this.addPrizeForm.valid) {
      this.prizeService.createPrize({
        prizeName: this.addPrizeForm.value.prizeName,
        points: this.addPrizeForm.value.prizePoints,
      }).subscribe({
        next: () => {
          this.dialogRef.close()
        }
      })
    }
  }
}
