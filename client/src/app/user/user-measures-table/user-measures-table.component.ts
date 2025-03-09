import {Component, input} from '@angular/core';
import {ISAKMeasuresModel} from '../../models/measure.models';
import {JsonPipe} from '@angular/common';
import {MatDivider} from '@angular/material/divider';
import {
  MatList,
  MatListItem,
  MatListItemLine,
  MatListItemTitle,
  MatListSubheaderCssMatStyler
} from '@angular/material/list';
import {
  MatAccordion,
  MatExpansionPanel,
  MatExpansionPanelHeader,
  MatExpansionPanelTitle
} from '@angular/material/expansion';

@Component({
  selector: 'app-user-measures-table',
  imports: [
    JsonPipe,
    MatDivider,
    MatList,
    MatExpansionPanelHeader,
    MatListItem,
    MatListItemTitle,
    MatListItemLine,
    MatAccordion,
    MatExpansionPanel,
    MatExpansionPanelTitle
  ],
  templateUrl: './user-measures-table.component.html',
  styleUrl: './user-measures-table.component.scss'
})
export class UserMeasuresTableComponent {
  ISAKMeasures = input.required<ISAKMeasuresModel>()

}
