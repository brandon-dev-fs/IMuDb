import { useState } from 'react';

const ROOT_API = 'https://localhost:3001/api/';

export default function useApi(endpoint) {
	const [data, setData] = useState([]);
	const url = `${ROOT_API}${endpoint}`;

	console.log('In use api hook');

	fetch(url)
		.then((res) => res.json())
		.then((rData) => setData(rData));

	console.log(data);

	return data;
}
