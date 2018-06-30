# Parking system
Sistema de gerenciamento de estacionamento

O sistema será programado usando C#.

A idéia é um sistema de gerenciamento de estacionamento, com:
- Sistema de login com nivel de acesso (Admin, Funcionário)
- Cadastro de Cliente (admin e funcionário podem fazer)
- Cadastro de Funcionário (somente admin faz)
- Cadastro de Serviços (Estacionar, Lava Car, Mecanina, Revisão tipo isso)
- Cadastro de comanda, onde é executado o serviço para clientes
- Cadastro de Vaga

Classes:
- Usuario
- Servico
- VeiculoTipo (Bicicleta, Ciclomotor, Motoneta, Motocicleta, Triciclo, Quadriciclo, Automóvel, Microônibus, Onibus, Charrete, Caminhão, Automobilístico, Trator, Especial, Coleção) 
- Veiculo
- ComandaStatus (Reservada, Ativa, Fechada)
- Comanda
- VagaTipo (Pequena, Média, Grande, Extra Grande)
- Vaga
