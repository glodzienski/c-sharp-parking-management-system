# parking system
Sistema de gerenciamento de estacionamento

O sistema será programado usando C#.

A idéia é um sistema de gerenciamento de estacionamento, com:
- Sistema de login com nivel de acesso (Admin, Cliente, Funcionário)
- Cadastro de Cliente (admin e funcionário pode fazer)
- Cadastro de Funcionário (somente admin faz)
- Cadastro de Serviços (Estacionar, Lava Car, Mecanina, Revisão tipo isso)
- Cadastro de Pacotes (Vários serviços)
- Cadastro de comanda, onde é executado o serviço ou pacote para clientes ou não clientes.
- Cadastro de Vaga

Classes:
- UsuarioTipo (Funcionario, Cliente, Admin)
- Usuario
- Servico
- Pacote
- PacoteServico
- VeiculoTipo (Bicicleta, Ciclomotor, Motoneta, Motocicleta, Triciclo, Quadriciclo, Automóvel, Microônibus, Onibus, Charrete, Caminhão, Automobilístico, Trator, Especial, Coleção) 
- Veiculo
- ComandaStatus (Reservada, Ativa, Fechada)
- ComandaItem
- Comanda
- VagaTipo
- Vaga
