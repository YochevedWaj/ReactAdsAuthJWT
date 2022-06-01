import React, { useEffect, useState } from 'react';
import getAxios from '../AuthAxios';
import AdDisplay from '../Components/AdDisplay'

const MyAccount = () => {
    const [myAds, setMyAds] = useState([]);

    const geMyAds = async () => {
        const { data } = await getAxios().get('/api/ads/getmyads');
        setMyAds(data);
    }

    useEffect(() => {
        geMyAds();

    }, []);

    const onDeleteClick = async (id) => {
        await getAxios().post('/api/ads/deletead', { id });
        await geMyAds();
    }

    return (<div className="container">
        <div className="row">
            <div className="col-md-6 offset-md-3">
                {myAds.map(a => <AdDisplay ad={a}
                    key={a.id}
                    onDeleteClick={() => onDeleteClick(a.id)}
                    canDelete={true} />)}
            </div>
        </div>
    </div>)
}

export default MyAccount;