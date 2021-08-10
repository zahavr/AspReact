import React, { useEffect } from 'react';
import {Grid} from 'semantic-ui-react';
import {useStore} from '../../../app/stores/store';
import LoadingComponents from '../../../app/layout/LoadingComponent';
import { useParams } from 'react-router';
import { observer } from 'mobx-react-lite';
import ActivityDetailedHeader from './ActivityDetailedHeader';
import ActivityDetailedInfo from './ActivityDetailedInfo';
import ActivityDetailedChat from './ActivityDetailedChat';
import ActivityDetailedSideBar from './ActivityDetailedSideBar';

export default observer(function ActivityDetails() {
    const {activityStore} = useStore();
    const {selectedActivity: activity, loadActivity, loadingInitial} = activityStore;
    const {id} = useParams<{id: string}>();

    useEffect(() => {
        if(id) loadActivity(id);
    }, [id, loadActivity]);

    if (loadingInitial || !activity) return <LoadingComponents />

    return (
        <Grid>
            <Grid.Column width={10}>
                <ActivityDetailedHeader activity={activity} />
                <ActivityDetailedInfo activity={activity} />
                <ActivityDetailedChat />
            </Grid.Column>
            <Grid.Column width={6}>
                <ActivityDetailedSideBar />
            </Grid.Column>
        </Grid>
    )
})