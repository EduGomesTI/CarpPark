import { Component, OnInit } from '@angular/core';
import { Validators, FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-cadastrar-pf',
  templateUrl: './cadastrar-pf.component.html'
})
export class CadastrarPfComponent implements OnInit
{
  public form: FormGroup;

  constructor(private fb: FormBuilder)
  {
    this.form = this.fb.group({
      nome: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(40),
        Validators.required
      ])],

      cpf: ['', Validators.compose([
        Validators.minLength(11),
        Validators.maxLength(11),
        Validators.required
      ])],

      rg: ['', Validators.required],

      dataNascimento: ['', Validators.required],

      sexo: ['', Validators.compose([
        Validators.maxLength(1),
        Validators.required
      ])],

      logradouro: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(100),
        Validators.required
      ])],

      numero: ['', Validators.compose([
        Validators.minLength(1),
        Validators.maxLength(5),
        Validators.required
      ])],

      complemento: ['', Validators.maxLength(10)],
      bairro: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(40),
        Validators.required
      ])],

      cep: ['', Validators.compose([
        Validators.minLength(8),
        Validators.maxLength(8),
        Validators.required
      ])],

      cidade: ['', Validators.compose([
        Validators.minLength(3),
        Validators.maxLength(30),
        Validators.required
      ])],

      estado: ['', Validators.compose([
        Validators.minLength(2),
        Validators.maxLength(2),
        Validators.required
      ])],

      telefone1: ['', Validators.required],

      telefone2: ['', Validators.required],

      emailPessoal: ['', Validators.compose([
        Validators.email,
        Validators.required
      ])],

      emailCorporativo: ['', Validators.compose([
        Validators.email,
        Validators.required
      ])]
    });
  }

  submit(): void { }

  ngOnInit(): void
  {
  }

}
