# Spotify Album Request

Projeto Full‑Stack para consumo da API do Spotify, composto por **.NET 8 (Backend)** e **React + Vite (Frontend)**. O objetivo é demonstrar autenticação via Client Credentials, comunicação entre serviços, consumo de APIs externas (Refit) e uma interface moderna inspirada no Spotify.

---

##  Tecnologias Utilizadas

### **Backend (.NET 8)**

* ASP.NET Core Web API
* Refit para comunicação tipada com APIs externas
* Swagger (documentação automática)
* Dependency Injection
* CORS configurado para desenvolvimento

### **Frontend (React + Vite)**

* React 18
* Vite
* TailwindCSS
* Fetch API para consumo da API
* Estrutura limpa e simples


##  Interface do Projeto

A interface foi construída com **React + TailwindCSS**, inspirada no visual do Spotify, com botões arredondados, gradientes escuros e cartões de exibição dos álbuns.

```
[Botão] Carregar Álbuns
┌───────────────────────────────┐
│   Nome do Álbum               │
│   Lançamento: DD/MM/AAAA      │
└───────────────────────────────┘
```

---

##  Fluxo de Funcionamento

```
Frontend (React) ----request----> Backend (.NET)
Backend faz:
   - Autenticação Client Credentials no Spotify
   - Requisição de Novos Lançamentos
   - Retorna JSON para o Frontend
Frontend exibe em UI estilizada
```

---

## 📄 Licença

Este projeto é de livre estudo e pode ser usado como base para portfólio.

---

## 🤝 Contribuições

Contribuições são bem‑vindas! Sinta‑se livre para abrir issues e pull requests.

---

## ⭐ Mostre seu apoio

Se este projeto te ajudou, deixe uma estrela no repositório!
