import axios from 'axios';

export const HTTP = axios.create({
    baseURL: 'https://localhost:5001/', // TODO сделать настраиваемым
    headers: {
        Authorization: localStorage.getItem('access_token')
            ? `Bearer ${localStorage.getItem('access_token')}`
            : null
    }
}); 