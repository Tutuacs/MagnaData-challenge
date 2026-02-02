import axios from 'axios';

const BASE_API_URL = 'http://localhost:5284';

export const apiClient = axios.create({
  baseURL: BASE_API_URL,
  headers: {
    'Content-Type': 'application/json',
  },
});