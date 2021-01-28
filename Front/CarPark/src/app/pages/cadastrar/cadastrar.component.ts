import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-cadastrar',
  templateUrl: './cadastrar.component.html'
})
export class CadastrarComponent implements OnInit
{
  public formPessoa: FormGroup;

  constructor(private fb: FormBuilder)
  {
    this.formPessoa = this.fb.group({});
  }

  ngOnInit(): void
  {
  }

}
