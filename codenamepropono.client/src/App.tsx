import { useEffect, useState } from 'react';
import './App.css';
import axios from "axios";

interface PhotoCardProps {
    id: number;
    photoUrl: string;
    location: string;
}

function App() {
    const [photoCards, setPhotoCards] = useState<PhotoCardProps[]>();

    useEffect(() => {
        populatePhotoCards();
    }, []);

    const contents = photoCards === undefined
        ? <p><em>Propono is firing up...</em></p>
        : <table className="table table-striped" aria-labelledby="tabelLabel">
            <thead>
                <tr>
                    <th>Url:</th>
                    <th>Location:</th>
                </tr>
            </thead>
            <tbody>
                {photoCards.map(photoCard =>
                    <tr key={photoCard.id}>
                        <td>{photoCard.photoUrl}</td>
                        <td>{photoCard.location}</td>
                    </tr>
                )}
            </tbody>
        </table>;

    return (
        <div>
            <h1 id="tabelLabel">Propono</h1>
            <p>This component demonstrates fetching data from the server.</p>
            {contents}
        </div>
    );

    //TODO: Axios? Change port
    // async function populatePhotoCards() {
    //     const response = await fetch('api/Photos');
    //     const data = await response.json();
    //     setPhotoCards(data);
    // }
    async function populatePhotoCards() {
        axios.get('api/Photos').then(response => {
            setPhotoCards(response.data);
        });
    }
}

export default App;