# parking
Sistema de gerenciamento de estacionamento

O sistema será programado usando C#.

A idéia é um sistema de gerenciamento de estacionamento, com:
- Sistema de login com nivel de acesso (Admin, Cliente, Funcionário)
- Cadastro de Cliente (admin e funcionário pode fazer)
- Cadastro de Funcionário (somente admin faz)
- Cadastro de Serviços (Estacionar, Lava Car, Mecanina, Revisão tipo isso)
- Cadastro de Pacotes (Vários serviços)
- Cadastro de comanda, onde é executado o serviço ou pacote para clientes ou não clientes.

Classes:
- Usuario
- Funcionario extends Usuario
- Cliente extends Usuario
- Servico
- Pacote
- Veiculo
- Bicicleta extends Veiculo
- Ciclomotor extends Veiculo
- Motoneta extends Veiculo
- Motocicleta extends Veiculo
- Triciclo extends Veiculo
- Quadriciclo extends Veiculo
- Automóvel extends Veiculo
- Microônibus extends Veiculo
- Ônibus extends Veiculo
- Charrete extends Veiculo
- Caminhão extends Veiculo
- Automobilístico extends Veiculo
- Trator extends Veiculo
- Especial extends Veiculo
- Coleção extends Veiculo
- Comanda
- Vaga
