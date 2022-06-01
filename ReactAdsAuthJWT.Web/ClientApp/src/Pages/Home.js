import React, { useEffect, useState } from 'react';
import getAxios from '../AuthAxios';
import AdDisplay from '../Components/AdDisplay';

const Home = () => {
    const [adVms, setAdVms] = useState([]);

    const geAds = async () => {
        const { data } = await getAxios().get('/api/ads/getads');
        setAdVms(data);
    }

    useEffect(() => {
        geAds();

    }, []);

    const onDeleteClick = async (id) => {
        await getAxios().post('/api/ads/deletead', { id });
        await geAds();
    }


    return (<div className="container">
        <div className="row">
            <div className="col-md-6 offset-md-3">
                {adVms.map(vm => <AdDisplay ad={vm.ad}
                    userName={vm.userName}
                    key={vm.ad.id}
                    onDeleteClick={() => onDeleteClick(vm.ad.id)}
                    canDelete={vm.canDelete} />)}
            </div>
        </div>
    </div>)
}

export default Home;