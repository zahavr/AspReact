import { format } from 'date-fns';
import React from 'react'
import { Link } from 'react-router-dom';
import { Button, Icon, Item, Segment } from 'semantic-ui-react';
import { Activity } from '../../../app/models/activity';

interface Props {
    activity: Activity
}

export default function ActivityListItem({activity}: Props) {
    // const {activityStore} = useStore();
    // const {deleteActivity, loading} = activityStore;

    // const  [target, setTarget] = useState('');

    // function handleActivityDelete(event: SyntheticEvent<HTMLButtonElement>, id: string) {
    //     setTarget(event.currentTarget.name);
    //     deleteActivity(id);
    // }
    
    return(
        <Segment.Group>
            <Segment>
                <Item.Group>
                    <Item>
                        <Item.Image size='tiny' circular src='assets/user.png' />
                        <Item.Content>
                            <Item.Header as={Link} to={`/activities/${activity.id}`}>
                                {activity.title}
                            </Item.Header>
                        </Item.Content>
                        <Item.Description>
                            Hosted by Bob
                        </Item.Description>
                    </Item>
                </Item.Group>
            </Segment>
            <Segment>
                <span>
                    <Icon name='clock'/> {format(activity.date!, 'dd MMM yyyy h:mm aa')}
                    <Icon name='marker' /> {activity.venue}
                </span>
            </Segment>
            <Segment secondary>
                Attends go here
            </Segment>
            <Segment clearing>
                <span>{activity.description}</span>
                <Button 
                    as={Link}
                    to={`/activities/${activity.id}`}
                    color='teal'
                    floated='right'
                    content='View'
                />
            </Segment>
        </Segment.Group>
    );
}